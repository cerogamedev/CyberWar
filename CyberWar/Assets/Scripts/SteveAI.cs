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
        // Örnek bir diyalog metni
        dialogWords = new string[]
        {
            "Merhaba, ben bir diyalog sistemiyim.",
            "Bu cümleleri teker teker okuyarak devam etmek için sol týkla.",
            "Þimdi sana iki seçenek sunacaðým.",
            "Buton 1'e týkla.",
            "Veya Buton 2'ye týkla."
        };



        // Butonlara fonksiyonlarý baðla
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


        // Sol týklama ile bir sonraki kelimeye geç
        if (Input.GetMouseButtonDown(0) && !dialogCompleted)
        {
            ShowNextWord();
        }
    }

    void ShowNextWord()
    {
        // Tüm kelimeler tamamlandý mý kontrol et
        if (currentWordIndex < dialogWords.Length)
        {
            // Bir sonraki kelimeyi göster
            dialogText.text = dialogWords[currentWordIndex];
            currentWordIndex++;
        }
        else
        {
            // Tüm diyalog tamamlandý, butonlarý etkinleþtir
            dialogCompleted = true;
            optionButton1.gameObject.SetActive(true);
            optionButton2.gameObject.SetActive(true);
        }
    }

    void Option1Selected()
    {
        // Buton 1'e týklanýnca yapýlacak iþlemler
        Debug.Log("Buton 1 seçildi. Buton 1'e özel iþlemler yapýlabilir.");
        Time.timeScale = 1;
    }

    void Option2Selected()
    {
        // Buton 2'ye týklanýnca yapýlacak iþlemler
        Debug.Log("Buton 2 seçildi. Buton 2'ye özel iþlemler yapýlabilir.");
        Time.timeScale = 1;

    }
}
