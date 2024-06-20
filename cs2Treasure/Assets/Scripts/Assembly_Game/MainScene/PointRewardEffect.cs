using Cysharp.Threading.Tasks;
using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointRewardEffect : MonoBehaviour {
    public static PointRewardEffect Instance;
    [SerializeField] Transform SpawnParent;
    [SerializeField] float MoveSpeed = 500;
    [SerializeField] float DestroyDist = 70;
    [SerializeField] int DontDestryAfterMiliSecs = 50;
    [SerializeField] int MaxSpawnVelocity = 400;
    [SerializeField] float Lerp = 0.001f;
    [SerializeField] GameObject PointEffectPrefab;
    [SerializeField] Transform Target;
    [SerializeField] GameObject GlowEffectPrefab;

    List<Rigidbody2D> Particles = new List<Rigidbody2D>();


    public void Init() {
        Instance = this;
    }
    public void PlayReward(int _odds) {
        int spawnCount = 3 + _odds * 3;
        if (spawnCount > 0) SpanwParticles(spawnCount);
    }

    void SpanwParticles(int _count) {
        for (int i = 0; i < _count; i++) {
            SpanwParticle();
        }
    }
    void SpanwParticle() {
        var go = Instantiate(PointEffectPrefab, SpawnParent);
        Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
        if (rigid == null) return;
        rigid.velocity = GetRndVelocity();
        Particles.Add(rigid);
        MoveParticles().Forget();
    }
    Vector2 GetRndVelocity() {
        int randForce = Random.Range(MaxSpawnVelocity / 2, MaxSpawnVelocity);
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return randForce * direction.normalized;
    }
    async UniTask MoveParticles() {
        bool loop = true;
        // 前幾秒不可以刪除粒子
        bool canDestroy = false;
        UniTask.Void(async () => {
            //await UniTask.Delay(DontDestryAfterMiliSecs);
            canDestroy = true;
            await UniTask.Delay(3000);
            loop = false;
        });


        while (loop) {
            List<Rigidbody2D> toRemove = new List<Rigidbody2D>();

            if (canDestroy) {
                foreach (var particle in Particles) {
                    if (particle != null) {
                        var posDiff = (Vector2)Target.localPosition - (Vector2)particle.transform.localPosition;
                        if (posDiff.magnitude < DestroyDist) {
                            Destroy(particle.gameObject);
                            toRemove.Add(particle);
                        }
                    }
                }

                foreach (var particle in toRemove) {
                    Particles.Remove(particle);
                }

                if (Particles.Count == 0) {
                    loop = false;
                    break;
                }
            }

            //粒子移動
            foreach (var particle in Particles) {
                if (particle != null) {
                    Vector2 targetVol = (Target.localPosition - particle.transform.localPosition).normalized * MoveSpeed;
                    particle.velocity = Vector2.Lerp(particle.velocity, targetVol, Lerp);
                }
            }
            await UniTask.Delay(100);
        }

        await UniTask.Delay(100);
    }

}
