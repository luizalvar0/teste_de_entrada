g
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class comandosbasicos : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    public float velocidade;
    private float direcaoMovimento;
    private Vector2 movimento;
    private Vector3 direção;
    private bool isAnim;
    private int pontuacao;
    public TextMeshProUGUI txtpontuacao;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direção = new Vector3(movimento.x, 0, movimento.y);
        controller.Move(direção * velocidade * Time.deltaTime);

        isAnim = false;

        if(direção.magnitude > 0)
        {
            direcaoMovimento = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, direcaoMovimento, 0);
            isAnim = true;
        }
        anim.SetBool("RUN", isAnim);

       
    }
    public void Move(InputAction.CallbackContext value)
    {
        movimento = value.ReadValue<Vector2>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.tag == "coletavel")
        {
            pontuacao += 1;
            Destroy(Other.gameObject);
        }
      
        if (Other.gameObject.tag == "coletavel2")
        {
            pontuacao += 3;
            Destroy(Other.gameObject);
        }
        if (Other.gameObject.tag == "coletavel3")
        {
            pontuacao -= 1;
            Destroy(Other.gameObject);
        }

        txtpontuacao.text = pontuacao.ToString();


    }
}
