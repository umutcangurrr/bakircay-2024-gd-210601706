using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI (Button/Image) kullan�m� i�in gerekli

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
        // Oyuna ilk girildi�inde meyveleri spawn et
        SpawnObjects();
    }

    void Update()
    {
        // 1) Listede null (yok edilmi�) objeler varsa ay�kla
        spawnedObjects.RemoveAll(obj => obj == null);

        // 2) E�er sahnedeki t�m meyveler yok edilmi�se tekrar spawn et
        if (spawnedObjects.Count == 0)
        {
            SpawnObjects();
        }

        // 3) E Skill cooldown timer'�n� g�ncelle
        if (eSkillCooldownTimer > 0)
        {
            eSkillCooldownTimer -= Time.deltaTime;
        }
        else
        {
            // Cooldown bitti�inde E skill tekrar kullan�labilir olsun
            if (!canUseESkill)
            {
                canUseESkill = true;

                // E skill buton/g�rsel gizlenmi�se, tekrar g�ster
                if (eSkillImage != null && !eSkillImage.gameObject.activeSelf)
                {
                    eSkillImage.gameObject.SetActive(true);
                }
            }
        }
    }

    /// <summary>
    /// W Skill butonunun OnClick() event'ine ba�lanacak fonksiyon.
    /// </summary>
    public void OnWButtonClicked()
    {
        if (canUseWSkill)
        {
            // Golden Apple'� spawn et
            SpawnGoldenApple();
            // W skill 15 saniye devre d��� kals�n
            StartCoroutine(DisableWSkillTemporarily());
        }
    }

    /// <summary>
    /// E Skill butonunun OnClick() event'ine ba�lanacak fonksiyon.
    /// </summary>
    public void OnEButtonClicked()
    {
        // Hem skill kullan�labilir (canUseESkill = true) hem de cooldown s�resi bitmi�se
        if (canUseESkill && eSkillCooldownTimer <= 0)
        {
            ActivateESkill();
        }
    }

    private void ActivateESkill()
    {
        canUseESkill = false;
        eSkillCooldownTimer = eSkillCooldown; // 60 saniyelik cooldown ba�lat

        // E skill butonu/g�rselini gizle
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
        // dragObjects i�indeki her prefab i�in 2'�er adet spawn ediyoruz
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

        // W skill butonu/g�rselini gizle
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
        canUseWSkill = false; // 15 saniye boyunca kapal�

        yield return new WaitForSeconds(15f);

        // 15 saniye sonra W skill tekrar aktif edilsin
        canUseWSkill = true;

        // W buton/g�rseli tekrar g�r�n�r olsun
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
        // Merkezden radius mesafe i�inde rastgele bir konum
        Vector3 randomOffset = Random.insideUnitCircle * radius;
        var randomPosition = transform.position + randomOffset;
        // Y�kseklik olarak 2 veriyoruz, isterseniz de�i�tirebilirsiniz
        return new Vector3(randomPosition.x, 2, randomPosition.y);
    }

    // Sahnede k�renin �izilmesi (sadece editor i�in)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
