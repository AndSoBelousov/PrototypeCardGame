using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cards
{
public class Card : MonoBehaviour
{
        [SerializeField]
        private GameObject _frontCard;
        [SerializeField]
        private MeshRenderer _picture;
        [SerializeField]
        private TextMeshPro _cost;
        [SerializeField]
        private TextMeshPro _name;
        [SerializeField]
        private TextMeshPro _description;
        [SerializeField]
        private TextMeshPro _attack;
        [SerializeField]
        private TextMeshPro _health;
        [SerializeField]
        private TextMeshPro _type;

}
}
