using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Fight_PlayerController : MonoBehaviourPun
{
    private Animator anim;
    [SerializeField] private TextMeshPro nickName;

    [SerializeField] private GameObject punchBox;
    [SerializeField] private GameObject kickBox;

    private bool isAttack = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        // if (photonView.IsMine)
        // {
        //     nickName.text = PhotonNetwork.NickName;
        //     nickName.color = Color.green;
        // }
        // else
        // {
        //     nickName.text = photonView.Owner.NickName;
        //     nickName.color = Color.red;
        // }
    }

    void OnPunch()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine("Punch", 0.5f, 0.3f, punchBox));
    }

    void OnKick()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine("Kick", 0.6f, 0.2f, kickBox));
    }

    IEnumerator AttackRoutine(string parameter, float playTime, float endTime, GameObject hitBox)
    {
        isAttack = true;
        anim.SetTrigger(parameter);

        yield return new WaitForSeconds(playTime);
        hitBox.SetActive(true);

        yield return new WaitForSeconds(endTime);
        hitBox.SetActive(false);
        isAttack = false;
    }
}