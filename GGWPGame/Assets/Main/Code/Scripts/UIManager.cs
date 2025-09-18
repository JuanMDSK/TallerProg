using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text tituloText;
    [SerializeField]
    private TMP_Text alertasText;



    [SerializeField]
    private TMP_InputField respuestaInput;

    [SerializeField]
    private Button enviarbutton;

    [SerializeField]
    private int edad;

    private void Start()
    {
        tituloText.text = "Hola nigga, introduce tu edad ";
        alertasText.text = "";
        enviarbutton.onClick.AddListener(FuncionDelBoton);
    }

    private void FuncionDelBoton()
    {

        edad = int.Parse(respuestaInput.textComponent.text);
    }

}
