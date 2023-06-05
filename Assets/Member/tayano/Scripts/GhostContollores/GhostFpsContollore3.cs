using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFpsContollore3 : MonoBehaviour
{
    [SerializeField]
    float TpSec;
    //移動用変数
    float x, z;
    Vector3 posi;

    //スピード調整用の変数

    float speed = 0.1f;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    bool cursorLock = true;

    float minX = -90f, maxX = 90f;


    float Xsensityvity = 3f, Ysensityvity = 3f;
    //入力に合わせてプレイヤーの位置を変更していく

    //入力に合わせてプレイヤーの位置を変更していく

    //Kenshin5680による追記。ghostHp1というint型クラスを宣言。
    [SerializeField]
    public int ghostHp3;
    //ここまでがKenshin5680による追記。

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GhostTP3"))
        {
            StartCoroutine(Posi());
        }
        PersControll();
        UpdateCursorLock();
        GhostHP3();
}
    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("GhostHorizontal3") * speed;
        z = Input.GetAxisRaw("GhostVertical3") * speed;

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;


        //transform.position += new Vector3(x, 0, z);
        transform.position += camForward * z + cam.transform.right * x;
    }
    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;

        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, minX, maxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    private IEnumerator Posi()
    {
        posi = this.transform.position;
        yield return new WaitForSeconds(TpSec);
        transform.position = posi;
    }
    private void PersControll()
    {
        float xRot = Input.GetAxis("GhostCamX3") * Ysensityvity;
        float yRot = Input.GetAxis("GhostCamY3") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
    }

    private void GhostHP3()
    {
        if(ghostHp3<=0) {
            Destroy(this.gameObject);
        }
        
    }
}
