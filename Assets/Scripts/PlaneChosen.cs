using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneChosen : MonoBehaviour
{
    [SerializeField] Button plane1;
    [SerializeField] Button plane2;
    [SerializeField] Button plane3;
    [SerializeField] Player player;


    [SerializeField] Sprite plane_1;
    [SerializeField] Sprite plane_2;
    [SerializeField] Sprite plane_3;

    public static bool gameStart = false;

    private void Start() {
        plane1.onClick.AddListener(() => {
            player.ChosePlane(ResourceList.PLANE_1);
        });

        plane2.onClick.AddListener(() => {
            player.ChosePlane(ResourceList.PLANE_2);
        });

        plane3.onClick.AddListener(() => {
            player.ChosePlane(ResourceList.PLANE_3);
        });

    }

    private void Update() {
        if (gameStart) {
            plane1.gameObject.SetActive(false);
            plane2.gameObject.SetActive(false);
            plane3.gameObject.SetActive(false);
        }
    }
}
