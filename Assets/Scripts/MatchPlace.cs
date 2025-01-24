using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI kullanýmýna eriþim için gerekli

public class FruitContainer : MonoBehaviour
{
    private List<GameObject> _fruitsInContainer = new List<GameObject>();
    private int _score = 0;
    private Vector3 fixedPosition = new Vector3(-0.1f, 0.11f, 0.3f);
    private Animator childAnimator;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject qSkillButton; // Q skill buton referansý (Canvas üzerindeki Button)
    private bool isQActive = false;
    private bool canUseQ = true;
    private float qMultiplier = 1;

    private void Start()
    {
        Transform child = transform.Find("ChestV1_Top");
        if (child != null)
        {
            childAnimator = child.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Child not found!");
        }

        // Baþlangýç puanýný UI'ya yaz
        UpdateScoreUI();

        // Q Skill Button baþlangýçta aktif (kullanýlabilir)
        if (qSkillButton != null)
        {
            qSkillButton.SetActive(true);
        }
    }

    // Artýk Update() içinde Input kontrolü yapmýyoruz.
    // Çünkü skill buton üzerinden çalýþacak.

    /// <summary>
    /// UI butonunun OnClick olayý bu metodu çaðýracak.
    /// </summary>
    public void OnQButtonClicked()
    {
        if (canUseQ) // Skilli kullanabiliyorsak
        {
            StartCoroutine(ActivateQSkill());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eðer meyve ise listeye ekle ve kontrol et
        if (other.CompareTag("Moveable"))
        {
            // Nesneyi sabit pozisyona taþý
            other.transform.position = fixedPosition;
            Debug.Log($"'{other.name}' kabýn içine girdi ve konumu sabitlendi: {fixedPosition}");

            // Fiziði durdur
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Nesneyi listeye ekle ve kontrol et
            _fruitsInContainer.Add(other.gameObject);
            Debug.Log($"Sepete '{other.name}' eklendi.");
            CheckFruits(); // Meyve isimlerini kontrol et
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Meyve kabý terk ederse listeden çýkar
        if (other.CompareTag("Moveable"))
        {
            _fruitsInContainer.Remove(other.gameObject);
            Debug.Log($"'{other.name}' sepetten çýkarýldý.");
        }
    }

    private void CheckFruits()
    {
        // Eðer kapta 2 veya daha fazla nesne varsa kontrol et
        if (_fruitsInContainer.Count >= 2)
        {
            GameObject fruit1 = _fruitsInContainer[0];
            GameObject fruit2 = _fruitsInContainer[1];

            // Ýsimlerin baþ harflerini al
            char firstChar1 = fruit1.name[0];
            char firstChar2 = fruit2.name[0];

            if (firstChar1 == firstChar2)
            {
                // Baþ harfleri ayný ise puan ekle ve nesneleri yok et
                int points = GetPoints(firstChar1);
                childAnimator.SetTrigger("Close");
                _score += Mathf.RoundToInt(points * qMultiplier);
                UpdateScoreUI();
                Debug.Log($"Baþ harfler ayný ('{fruit1.name}', '{fruit2.name}')! Puan: +{points}. Toplam puan: {_score}");
                Destroy(fruit1);
                Destroy(fruit2);
                _fruitsInContainer.Remove(fruit1);
                _fruitsInContainer.Remove(fruit2);
            }
            else
            {
                // Baþ harfler farklý ise belirtilen noktalara ýþýnla
                Debug.Log($"Baþ harfler farklý ('{fruit1.name}', '{fruit2.name}')! Belirtilen konumlara ýþýnlanýyor.");
                TeleportToFixedPosition(fruit1, new Vector3(0, 0.426f, -2));
                TeleportToFixedPosition(fruit2, new Vector3(1, 0.426f, -2));
                _fruitsInContainer.Remove(fruit1);
                _fruitsInContainer.Remove(fruit2);
            }
        }
    }

    private int GetPoints(char firstChar)
    {
        // Baþ harfe göre puan döndüren yöntem
        switch (firstChar)
        {
            case 'A': return 5;
            case 'B': return 10;
            case 'C': return 15;
            case 'P': return 20;
            case 'T': return 25;
            case 'W': return 30;
            case 'O': return 35;
            case 'S': return 200;
            default: return 0;
        }
    }

    private void TeleportToFixedPosition(GameObject fruit, Vector3 targetPosition)
    {
        fruit.transform.position = targetPosition;
        Debug.Log($"'{fruit.name}' {targetPosition} konumuna ýþýnlandý.");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {_score}";
        }
        else
        {
            Debug.LogError("ScoreText is not assigned!");
        }
    }

    private IEnumerator ActivateQSkill()
    {
        // Q skilli aktif ediliyor
        isQActive = true;
        qMultiplier = 2;
        if (qSkillButton != null)
        {
            qSkillButton.SetActive(false); // Button'u tamamen gizle
        }

        Debug.Log("Q skilli aktif! Puanlar 2x oldu.");
        canUseQ = false;

        // 10 saniye skillin aktif olduðu süre
        yield return new WaitForSeconds(10);

        // Q skilli sona eriyor
        isQActive = false;
        qMultiplier = 1;
        Debug.Log("Q skilli sona erdi.");

        // 10 saniye de bekleme süresi (cooldown)
        yield return new WaitForSeconds(10);

        // Cooldown bittiðinde butonu tekrar göster
        if (qSkillButton != null)
        {
            qSkillButton.SetActive(true);
        }
        canUseQ = true;
    }
}
