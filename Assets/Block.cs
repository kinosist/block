using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitPoints = 1; // ブロックの耐久値
    public Material hitMaterial; // ヒット時に光るためのマテリアル
    private Material originalMaterial; // 元のマテリアル
    private Renderer blockRenderer;

    // Start is called before the first frame update
    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
        originalMaterial = blockRenderer.material; // 元のマテリアルを保存
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 衝突判定
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitPoints--; // 耐久力を減少させる

            // ヒット時に光る
            StartCoroutine(Glow());

            if (hitPoints <= 0)
            {
                Destroy(this.gameObject); // 耐久力が0以下になったらブロックを破壊する
            }
        }
    }

    public IEnumerator Glow()
    {
        blockRenderer.material = hitMaterial; // ヒット時のマテリアルに変更
        yield return new WaitForSeconds(0.1f); // 0.1秒間光る
        blockRenderer.material = originalMaterial; // 元のマテリアルに戻す
    }
}
