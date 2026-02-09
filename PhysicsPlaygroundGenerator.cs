using UnityEngine;

public class PhysicsPlaygroundGenerator : MonoBehaviour
{
    public float bumperForce = 600f;
    public float respawnDelay = 1f;
    public float targetResetTime = 2f;

    private Vector2 spawnPosition = new Vector2(0, 3);

    void Start()
    {
        CreateBall();
        CreateBoundaries();
        CreateDeathZone();
        CreateBumpers();
        CreateTargets();
    }

    void CreateBall()
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Quad);
        ball.name = "Ball";
        ball.transform.position = spawnPosition;
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        ball.tag = "Player";

        Destroy(ball.GetComponent<MeshCollider>());

        ball.AddComponent<CircleCollider2D>();
        Rigidbody2D rb = ball.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1;

        ball.AddComponent<BallRespawn>().Initialize(spawnPosition, respawnDelay);
    }

    void CreateBoundaries()
    {
        CreateWall("LeftWall", new Vector2(-6, 0), new Vector2(1, 12));
        CreateWall("RightWall", new Vector2(6, 0), new Vector2(1, 12));
        CreateWall("TopWall", new Vector2(0, 6), new Vector2(12, 1));
    }

    void CreateWall(string name, Vector2 pos, Vector2 scale)
    {
        GameObject wall = new GameObject(name);
        wall.transform.position = pos;
        wall.transform.localScale = scale;
        wall.AddComponent<BoxCollider2D>();
    }

    void CreateDeathZone()
    {
        GameObject dz = new GameObject("DeathZone");
        dz.transform.position = new Vector2(0, -6);
        dz.transform.localScale = new Vector2(12, 1);
        dz.tag = "DeathZone";

        BoxCollider2D col = dz.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
    }

    void CreateBumpers()
    {
        CreateBumper(new Vector2(-2, 0));
        CreateBumper(new Vector2(2, 0));
    }

    void CreateBumper(Vector2 pos)
    {
        GameObject bumper = GameObject.CreatePrimitive(PrimitiveType.Quad);
        bumper.name = "Bumper";
        bumper.transform.position = pos;
        bumper.transform.localScale = new Vector3(1, 1, 1);

        Destroy(bumper.GetComponent<MeshCollider>());
        bumper.AddComponent<BoxCollider2D>();
        bumper.AddComponent<Bumper>().force = bumperForce;
    }

    void CreateTargets()
    {
        CreateTarget(new Vector2(-3, 2));
        CreateTarget(new Vector2(3, 2));
    }

    void CreateTarget(Vector2 pos)
    {
        GameObject target = GameObject.CreatePrimitive(PrimitiveType.Quad);
        target.name = "Target";
        target.transform.position = pos;
        target.transform.localScale = new Vector3(1, 1, 1);

        Destroy(target.GetComponent<MeshCollider>());
        BoxCollider2D col = target.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        target.AddComponent<Target>().Initialize(targetResetTime);
    }
}
