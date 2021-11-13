//using System.Collections;
//using UnityEngine;

//public class Spoiling : MonoBehaviour
//{
//    public bool IsSpoil => _isSpoil;
//    public float SpoilTime => _spoilTime;
//    public delegate bool SpoilOperation();

//    private bool _isSpoil;
//    private float _spoilTime = 0f;
//    private float _rootingTime = 0f;
//    private AbstractFarmObject _farmObject;


//    public void Init(AbstractFarmObject farmObject, float rootingTime, float spoilTime)
//    {
//        _spoilTime = spoilTime;
//        _rootingTime = rootingTime;
//        _farmObject = farmObject;
//    }

//    public bool StartSpoil(SpoilOperation RootingOperation)
//    {
//        if(!_isSpoil)
//        {
//            StartCoroutine(Spoil(RootingOperation));
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    private IEnumerator Spoil(SpoilOperation RootingOperation)
//    {
//        _isSpoil = true;
//        while (_spoilTime < _rootingTime)
//        {
//            yield return new WaitForSeconds(1f);

//            if (!RootingOperation())
//            {
//                break;
//            }
//            else
//            {
//                _spoilTime += 1f;
//            }
//        }

//        _spoilTime = 0f;
//        _isSpoil = false;

//        if (RootingOperation())
//        {
//            _farmObject.Clear();
//        }
//    }
//}
