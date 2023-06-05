using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public int lightPower = 500;
    //light�̎c�e��

    [SerializeField]
    int lightDamege;
    //light�̃_���[�W���l��Unity������ύX�\�ɂ���

    int ghostHpCopy = 0;
    //ghost��HP���}�C�i�X���鎞�Ɏg���l�̈ꎞ�ۑ��p�ϐ�

    Transform streamerPosition;
    Vector3 direction;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask hitLayers;

    RaycastHit hit;
    Camera streamerCamera;

    
    
    


    void Awake()
    {
        streamerPosition = GameObject.Find("WhiteLight").transform;
        streamerCamera = GameObject.Find("StreamerCamera").GetComponent<Camera>();

    }


    void FixedUpdate()
    {

        Ray ray = streamerCamera.ScreenPointToRay(this.gameObject.transform.position);

        if (Input.GetButton("Fire1"))
        {
            lightPower --;
            //Debug.Log(lightPower);
            if(lightPower > 0)
            {
                if (Physics.Raycast(streamerPosition.position, streamerPosition.forward, out hit, maxDistance, hitLayers))
                {
                    GameObject hitGhost = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.Log(hit.collider.gameObject.tag);

                    //��LDebug.Log�͐���ɋ@�\���Ă���B

                    if (hitGhost.tag == "Ghost1")
                    {
                        GhostFpsContollore1 GhostFpsContollore = hitGhost.GetComponent<GhostFpsContollore1>();
                        if (GhostFpsContollore != null)
                        {
                            ghostHpCopy = GhostFpsContollore.ghostHp1;
                            GhostFpsContollore.ghostHp1 = ghostHpCopy - lightDamege;
                            Debug.Log(GhostFpsContollore.ghostHp1);

                        }
                    }

                    else if (hitGhost.tag == "Ghost2")
                    {
                        GhostFpsContollore2 GhostFpsContollore = hitGhost.GetComponent<GhostFpsContollore2>();
                        if (GhostFpsContollore != null)
                        {
                            ghostHpCopy = GhostFpsContollore.ghostHp2;
                            GhostFpsContollore.ghostHp2 = ghostHpCopy - lightDamege;
                        }
                    }

                    else if (hitGhost.tag == "Ghost3")
                    {
                        GhostFpsContollore3 GhostFpsContollore = hitGhost.GetComponent<GhostFpsContollore3>();
                        if (GhostFpsContollore != null)
                        {
                            ghostHpCopy = GhostFpsContollore.ghostHp3;
                            GhostFpsContollore.ghostHp3 = ghostHpCopy - lightDamege;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("�o�b�e���[���؂�܂����B");
            }
        }
    }


    }

