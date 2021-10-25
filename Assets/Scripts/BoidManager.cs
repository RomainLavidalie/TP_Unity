using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    private static BoidManager instance = null;

    public static BoidManager sharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<BoidManager>();
            }

            return instance;
        }
    }

    public Boid prefabBoid;
    public float nbBoids = 100;
    public float startSpeed = 1;
    public float startSpread = 10;

    public float maxDistBoids = 30;

    public float periodRetargetBoids = 6;
    public float periodNoTargetBoids = 3;
    private float timerRetargetBoids = 0;
    private bool setTargetToBoids = true;
    [SerializeField] private float landingTimer = 10;
    private float landingTimerLock;
    public bool landingPhase = false;
    public bool cameraOnBoid = false;
    private Vector3 initTransformPos;
    private Quaternion initTransformRot;

    private List<Boid> boids = new List<Boid>();

    public ReadOnlyCollection<Boid> roBoids
    {
        get { return new ReadOnlyCollection<Boid>(boids); }
    }

    void Start()
    {
        landingTimerLock = landingTimer;
        for (int i = 0; i < nbBoids; i++)
        {
            Boid b = GameObject.Instantiate<Boid>(prefabBoid);
            Vector3 positionBoid = Random.insideUnitSphere * startSpread;
            positionBoid.y =
                Mathf.Abs(positionBoid.y); //Ne pas créer des oiseaux sous 0, on imagine que ce sera le sol.
            b.transform.position = positionBoid;
            b.velocity = (positionBoid - transform.position).normalized * startSpeed;
            b.transform.parent = this.transform;
            b.maxSpeed *= Random.Range(0.95f, 1.05f);
            boids.Add(b);
        }

        initTransformPos = Camera.main.transform.position;
        initTransformRot = Camera.main.transform.rotation;
    }

    void Update()
    {
        //Décrémente la temporisation
        timerRetargetBoids -= Time.deltaTime;
        if (timerRetargetBoids <= 0)
        {
            if (!setTargetToBoids)
                timerRetargetBoids = periodNoTargetBoids;
            else
                timerRetargetBoids = periodRetargetBoids;

            Vector3 target = Random.insideUnitSphere * maxDistBoids;
            target.y = Mathf.Max(Mathf.Abs(target.y), 10);
            foreach (Boid b in boids)
            {
                b.goToTarget = false;
                if (setTargetToBoids && Random.Range(0.0f, 1.0f) < 0.3f)
                {
                    b.target = target;
                    b.goToTarget = true;
                }
            }
        }

        setTargetToBoids = !setTargetToBoids;
        landingTimer -= Time.deltaTime;

        if (landingTimer <= 0)
        {
            if (landingPhase)
                landingPhase = false;
            else
                landingPhase = true;
            landingTimer = landingTimerLock;
        }

        if (cameraOnBoid && Camera.main.transform.parent != boids[0].transform)
        {
            Camera.main.transform.SetParent(boids[0].transform);
            Camera.main.transform.position = boids[0].transform.position;
            Camera.main.transform.rotation = boids[0].transform.rotation;
        }

        else if (!cameraOnBoid && Camera.main.transform.parent == boids[0].transform)
        {
            Camera.main.transform.parent = null;
            Camera.main.transform.position = initTransformPos;
            Camera.main.transform.rotation = initTransformRot;
        }
    }
}