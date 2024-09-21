using Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Mob;

    private Player _player;
    private MobManager _mo;
    public BuffManager _bm;
    private CinemachineVirtualCamera _virtualCamera;
    private CoordinateProvider _coordinateProvider;
    
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

        _coordinateProvider = GetComponent<CoordinateProvider>();
        _bm = FindAnyObjectByType<BuffManager>();

        if (_mo && _mo.enabled)
        {
            _mo.Target = _player.transform;
            _mo.MobPrefab = Mob;
            _mo._CoordinateProvider = _coordinateProvider;
        }
        
        _bm._CoordinateProvider = _coordinateProvider;

        _player.GetComponent<Stats>().Speed = 5;
    }
    
    

  
}
