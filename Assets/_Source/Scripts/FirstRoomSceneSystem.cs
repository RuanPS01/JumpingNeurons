using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FirstRoomSceneSystem : MonoBehaviour
{
    [SerializeField]
    GameObject blazoCenterLyric;
    [SerializeField]
    GameObject blazoLyric;
    [SerializeField]
    GameObject jumperImages;
    [SerializeField]
    GameObject background;

    [SerializeField]
    TMP_Text blazoCenterLyricText;
    [SerializeField]
    TMP_Text blazoLyricText;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject playerCamera;


    [SerializeField]
    GameObject initialCamera;

    [SerializeField]
    AudioClip[] blazosNarrativeSequence;

    AudioSource audioSource;

    [SerializeField]
    bool showIntroductionAnimations = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if(showIntroductionAnimations) StartCoroutine(IntroductionOfScene());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator IntroductionOfScene()
    {
        // Part1
        background.SetActive(true);
        player.SetActive(false);
        playerCamera.SetActive(false);
        initialCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        blazoCenterLyric.SetActive(true);
        audioSource.clip = blazosNarrativeSequence[0];
        audioSource.Play();
        StartCoroutine(LyricPart1());
        yield return new WaitForSeconds(blazosNarrativeSequence[0].length);

        // Part2
        blazoCenterLyric.SetActive(false);
        jumperImages.SetActive(true);
        blazoLyric.SetActive(true);
        audioSource.clip = blazosNarrativeSequence[1];
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        StartCoroutine(LyricPart2());
        yield return new WaitForSeconds(blazosNarrativeSequence[1].length);

        // Part3
        jumperImages.SetActive(false);
        background.SetActive(false);
        player.SetActive(true);
        playerCamera.SetActive(true);
        initialCamera.SetActive(false);
        audioSource.clip = blazosNarrativeSequence[2];
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        StartCoroutine(LyricPart3());
        yield return new WaitForSeconds(blazosNarrativeSequence[2].length);

        blazoLyric.SetActive(false);
    }

    IEnumerator LyricPart1()
    {
        blazoCenterLyricText.text = "Ol� eu sou Blazo. N�o tenho uma not�cia muito boa. Diagnosticamos uma incapacidade l�gica em voc�, e precisamos tratar disso.";
        yield return new WaitForSeconds(10f);
        blazoCenterLyricText.text = "Felizmente j� temos o procedimento correto para te ajudar. Em nome da Brainter Science, te agrade�o por confiar em nosso trabalho!";
        yield return new WaitForSeconds(10f);
        blazoCenterLyricText.text = "Faremos um processo de regenera��o de neur�nios em voc� atrav�s de desafios pr�ticos, temos uma infraestrutura enorme para te ajudar.";
        yield return new WaitForSeconds(10f);
        blazoCenterLyricText.text = "Bem vindo ao Jumping Neurons, nosso ambiente de desenvolvimento l�gico para nossos clientes.";
        yield return new WaitForSeconds(7f);
    }

    IEnumerator LyricPart2()
    {
        blazoCenterLyricText.text = "...";
        blazoLyricText.text = "Para iniciar o procedimento, voc� precisa conhecer primeiramente sua ferramenta principal:";
        yield return new WaitForSeconds(6f);
        blazoLyricText.text = "Te apresento a Jumper Gun, ela � uma arma que gera Jumpers no ch�o ou em paredes. Os Jumpers gerados impulsionam voc� contra eles,";
        yield return new WaitForSeconds(9f);
        blazoLyricText.text = "fazendo voc� saltar bem alto, de acordo com a dire��o que ele estiver.";
        yield return new WaitForSeconds(5f);
    }

    IEnumerator LyricPart3()
    {
        blazoLyricText.text = "Voc� tem muito potencial para passar neste e em muitos outros procedimentos. No momento, quero ver como voc� sair� desta sala usando os Jumpers.";
        yield return new WaitForSeconds(9f);
        blazoLyricText.text = "Boa sorte!";
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitOfApplication()
    {
        Application.Quit();
    }
}
