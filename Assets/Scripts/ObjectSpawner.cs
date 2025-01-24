using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI (Button/Image) kullanýmý için gerekli

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private DragObject[] dragObjects;
    [SerializeField] private GameObject goldenApplePrefab;
    [SerializeField] private float radius;

    // Bu iki referans, UI'daki buton ya da Image objelerini temsil ediyor
    [SerializeField] private Image wSkillImage;
    [SerializeField] private Image eSkillImage;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private bool canUseWSkill = true;
    private bool canUseESkill = true;

    private float eSkillCooldown = 60f;
    private float eSkillCooldownTimer = 0f;

    void Start()
    {
        // Oyuna ilk girildiðinde meyveleri spawn et
        SpawnObjects();
    }

    void Update()
    {
        // 1) Listede null (yok edilmiþ) objeler varsa ayýkla
        spawnedObjects.RemoveAll(obj => obj == null);

        // 2) Eðer sahnedeki tüm meyveler yok edilmiþse tekrar spawn et
        if (spawnedObjects.Count == 0)
        {
            SpawnObjects();
        }

        // 3) E Skill cooldown timer'ýný güncelle
        if (eSkillCooldownTimer > 0)
        {
            eSkillCooldownTimer -= Time.deltaTime;
        }
        else
        {
            // Cooldown bittiðinde E skill tekrar kullanýlabilir olsun
            if (!canUseESkill)
            {
                canUseESkill = true;

                // E skill buton/görsel gizlenmiþse, tekrar göster
                if (eSkillImage != null && !eSkillImage.gameObject.activeSelf)
                {
                    eSkillImage.gameObject.SetActive(true);
                }
            }
        }
    }

    /// <summary>
    /// W Skill butonunun OnClick() event'ine baðlanacak fonksiyon.
    /// </summary>
    public void OnWButtonClicked()
    {
        if (canUseWSkill)
        {
            // Golden Apple'ý spawn et
            SpawnGoldenApple();
            // W skill 15 saniye devre dýþý kalsýn
            StartCoroutine(DisableWSkillTemporarily());
        }
    }

    /// <summary>
    /// E Skill butonunun OnClick() event'ine baðlanacak fonksiyon.
    /// </summary>
    public void OnEButtonClicked()
    {
        // Hem skill kullanýlabilir (canUseESkill = true) hem de cooldown süresi bitmiþse
        if (canUseESkill && eSkillCooldownTimer <= 0)
        {
            ActivateESkill();
        }
    }

    private void ActivateESkill()
    {
        canUseESkill = false;
        eSkillCooldownTimer = eSkillCooldown; // 60 saniyelik cooldown baþlat

        // E skill butonu/görselini gizle
        if (eSkillImage != null)
        {
            eSkillImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("E Skill Image is not assigned!");
        }

        // Meyvelerden 2 adet daha spawn et
        SpawnObjects();

        Debug.Log("E skill aktif! Meyveler tekrar spawn edildi.");
    }

    private void SpawnObjects()
    {
        // dragObjects içindeki her prefab için 2'þer adet spawn ediyoruz
        foreach (var dragObject in dragObjects)
        {
            for (int i = 0; i < 2; i++)
            {
                var instance = Instantiate(dragObject.Prefab, transform);
                instance.transform.localPosition = GetRandomPosition();
                spawnedObjects.Add(instance);
            }
        }
    }

    private void SpawnGoldenApple()
    {
        if (goldenApplePrefab != null)
        {
            for (int i = 0; i < 2; i++)
            {
                var goldenAppleInstance = Instantiate(goldenApplePrefab, transform);
                goldenAppleInstance.transform.localPosition = GetRandomPosition();
                spawnedObjects.Add(goldenAppleInstance);
            }
            Debug.Log("Golden Apple spawned!");
        }
        else
        {
            Debug.LogError("Golden Apple Prefab is not assigned!");
        }

        // W skill butonu/görselini gizle
        if (wSkillImage != null)
        {
            wSkillImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("W Skill Image is not assigned!");
        }
    }

    private System.Collections.IEnumerator DisableWSkillTemporarily()
    {
        canUseWSkill = false; // 15 saniye boyunca kapalý

        yield return new WaitForSeconds(15f);

        // 15 saniye sonra W skill tekrar aktif edilsin
        canUseWSkill = true;

        // W buton/görseli tekrar görünür olsun
        if (wSkillImage != null)
        {
            wSkillImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("W Skill Image is not assigned!");
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Merkezden radius mesafe içinde rastgele bir konum
        Vector3 randomOffset = Random.insideUnitCircle * radius;
        var randomPosition = transform.position + randomOffset;
        // Yükseklik olarak 2 veriyoruz, isterseniz deðiþtirebilirsiniz
        return new Vector3(randomPosition.x, 2, randomPosition.y);
    }

    // Sahnede kürenin çizilmesi (sadece editor için)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
