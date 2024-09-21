using Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Mob;

    private Player _player;
    private MobManager _mo;
    private CinemachineVirtualCamera _virtualCamera;
    void Awake()
    {
        Debug.Log("This is where the real game begins");

        _virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        if (!_virtualCamera)
        {
            Debug.Break();
            //instntiate
        }

        _mo = FindAnyObjectByType<MobManager>();
        if (!_mo)
        {
            Debug.Break();
            //instntiate
        }

        _player = FindAnyObjectByType<Player>();
        if (!_player)
        {
            Debug.Break();
            //instntiate
        }

        _mo.Target = _player.transform;
        _mo.MobPrefab = Mob;


        _player.GetComponent<Stats>().Speed = 5;
    }
    
    

  
}
