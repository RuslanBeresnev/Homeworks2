using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������� �����
/// </summary>
public class EnemyController : MonoBehaviour
{
    private GameObject target;

    private float moveSpeed = 4f;

    /// <summary>
    /// ��� ��� ������ ����
    /// </summary>
    public string TargetName { get; set; } = "Player";

    /// <summary>
    /// ����� �� ���� ��������� �� �����
    /// </summary>
    public bool FollowsTheTarget { get; private set; } = true;

    private void Start()
    {
        target = GameObject.Find(TargetName);
        target.GetComponent<AudioSource>().Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Game Over Menu");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void FixedUpdate()
    {
        if (FollowsTheTarget)
        {
            FollowTheTarget();
        }

        transform.Rotate(new Vector3(0f, -2f, 0f));
    }

    /// <summary>
    /// ��������� �� �����
    /// </summary>
    private void FollowTheTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.fixedDeltaTime);
    }
}