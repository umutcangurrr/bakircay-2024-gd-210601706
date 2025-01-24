using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI kullan�m�na eri�im i�in gerekli

public class FruitContainer : MonoBehaviour
{
    private List<GameObject> _fruitsInContainer = new List<GameObject>();
    private int _score = 0;
    private Vector3 fixedPosition = new Vector3(-0.1f, 0.11f, 0.3f);
    private Animator childAnimator;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject qSkillButton; // Q skill buton referans� (Canvas �zerindeki Button)
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

        // Ba�lang�� puan�n� UI'ya yaz
        UpdateScoreUI();

        // Q Skill Button ba�lang��ta aktif (kullan�labilir)
        if (qSkillButton != null)
        {
            qSkillButton.SetActive(true);
        }
    }

    // Art�k Update() i�inde Input kontrol� yapm�yoruz.
    // ��nk� skill buton �zerinden �al��acak.

    /// <summary>
    /// UI butonunun OnClick olay� bu metodu �a��racak.
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
        // E�er meyve ise listeye ekle ve kontrol et
        if (other.CompareTag("Moveable"))
        {
            // Nesneyi sabit pozisyona ta��
            other.transform.position = fixedPosition;
            Debug.Log($"'{other.name}' kab�n i�ine girdi ve konumu sabitlendi: {fixedPosition}");

            // Fizi�i durdur
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
        // Meyve kab� terk ederse listeden ��kar
        if (other.CompareTag("Moveable"))
        {
            _fruitsInContainer.Remove(other.gameObject);
            Debug.Log($"'{other.name}' sepetten ��kar�ld�.");
        }
    }

    private void CheckFruits()
    {
        // E�er kapta 2 veya daha fazla nesne varsa kontrol et
        if (_fruitsInContainer.Count >= 2)
        {
            GameObject fruit1 = _fruitsInContainer[0];
            GameObject fruit2 = _fruitsInContainer[1];

            // �simlerin ba� harflerini al
            char firstChar1 = fruit1.name[0];
            char firstChar2 = fruit2.name[0];

            if (firstChar1 == firstChar2)
            {
                // Ba� harfleri ayn� ise puan ekle ve nesneleri yok et
                int points = GetPoints(firstChar1);
                childAnimator.SetTrigger("Close");
                _score += Mathf.RoundToInt(points * qMultiplier);
                UpdateScoreUI();
                Debug.Log($"Ba� harfler ayn� ('{fruit1.name}', '{fruit2.name}')! Puan: +{points}. Toplam puan: {_score}");
                Destroy(fruit1);
                Destroy(fruit2);
                _fruitsInContainer.Remove(fruit1);
                _fruitsInContainer.Remove(fruit2);
            }
            else
            {
                // Ba� harfler farkl� ise belirtilen noktalara ���nla
                Debug.Log($"Ba� harfler farkl� ('{fruit1.name}', '{fruit2.name}')! Belirtilen konumlara ���nlan�yor.");
                TeleportToFixedPosition(fruit1, new Vector3(0, 0.426f, -2));
                TeleportToFixedPosition(fruit2, new Vector3(1, 0.426f, -2));
                _fruitsInContainer.Remove(fruit1);
                _fruitsInContainer.Remove(fruit2);
            }
        }
    }

    private int GetPoints(char firstChar)
    {
        // Ba� harfe g�re puan d�nd�ren y�ntem
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
        Debug.Log($"'{fruit.name}' {targetPosition} konumuna ���nland�.");
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

        // 10 saniye skillin aktif oldu�u s�re
        yield return new WaitForSeconds(10);

        // Q skilli sona eriyor
        isQActive = false;
        qMultiplier = 1;
        Debug.Log("Q skilli sona erdi.");

        // 10 saniye de bekleme s�resi (cooldown)
        yield return new WaitForSeconds(10);

        // Cooldown bitti�inde butonu tekrar g�ster
        if (qSkillButton != null)
        {
            qSkillButton.SetActive(true);
        }
        canUseQ = true;
    }
}
