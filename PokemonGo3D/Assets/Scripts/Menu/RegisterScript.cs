using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    [SerializeField]
    InputField usernameInput;
    [SerializeField]
    InputField passwordInput;
    [SerializeField]
    InputField emailInput;
    [SerializeField]
    Canvas principalCanvas;

	public void OnRegistrar()
    { 
        WWWForm form = new WWWForm();
        form.AddField("nicknamePost", usernameInput.text);
        form.AddField("passwordPost", passwordInput.text);
        form.AddField("emailPost", emailInput.text);

        WWW www = new WWW("http://localhost/Ben10RunPHP/RegisterPlayers.php", form);
    }
    public void OnVoltarAoMenu()
    {
        this.GetComponent<Canvas>().enabled = false;
        principalCanvas.enabled = true;
    }

}
