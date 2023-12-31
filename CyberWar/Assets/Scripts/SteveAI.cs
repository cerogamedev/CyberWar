using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SteveAI : MonoBehaviour
{
    public bool isClose, conStarts = false;
    public GameObject buttonSign;
    public GameObject ConvCanva;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClose = true;
            buttonSign.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClose = false;
            buttonSign.SetActive(false);
        }
    }
    public TextMeshProUGUI dialogText;
    public Button optionButton1;
    public Button optionButton2;

    private string[] dialogWords;
    private int currentWordIndex;
    private bool dialogCompleted;

    void Start()
    {
        // �rnek bir diyalog metni
        dialogWords = new string[]
        {
            "Merhaba, ben bir diyalog sistemiyim.",
            "Bu c�mleleri teker teker okuyarak devam etmek i�in sol t�kla.",
            "�imdi sana iki se�enek sunaca��m.",
            "Buton 1'e t�kla.",
            "Veya Buton 2'ye t�kla."
        };



        // Butonlara fonksiyonlar� ba�la
        optionButton1.onClick.AddListener(Option1Selected);
        optionButton2.onClick.AddListener(Option2Selected);
        optionButton1.gameObject.SetActive(false);
        optionButton2.gameObject.SetActive(false);
        ConvCanva.SetActive(false);
    }

    void Update()
    {
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            ConvCanva.SetActive(true);
            Time.timeScale = 0;
            ShowNextWord();
        }


        // Sol t�klama ile bir sonraki kelimeye ge�
        if (Input.GetMouseButtonDown(0) && !dialogCompleted)
        {
            ShowNextWord();
        }
    }

    void ShowNextWord()
    {
        // T�m kelimeler tamamland� m� kontrol et
        if (currentWordIndex < dialogWords.Length)
        {
            // Bir sonraki kelimeyi g�ster
            dialogText.text = dialogWords[currentWordIndex];
            currentWordIndex++;
        }
        else
        {
            // T�m diyalog tamamland�, butonlar� etkinle�tir
            dialogCompleted = true;
            optionButton1.gameObject.SetActive(true);
            optionButton2.gameObject.SetActive(true);
        }
    }

    void Option1Selected()
    {
        // Buton 1'e t�klan�nca yap�lacak i�lemler
        Debug.Log("Buton 1 se�ildi. Buton 1'e �zel i�lemler yap�labilir.");
        Time.timeScale = 1;
    }

    void Option2Selected()
    {
        // Buton 2'ye t�klan�nca yap�lacak i�lemler
        Debug.Log("Buton 2 se�ildi. Buton 2'ye �zel i�lemler yap�labilir.");
        Time.timeScale = 1;

    }
}
