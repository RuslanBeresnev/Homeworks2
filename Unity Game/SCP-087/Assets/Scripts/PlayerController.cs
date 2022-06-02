using UnityEngine;

/// <summary>
/// ���������� �������
/// </summary>
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 previousPosition;

    private AudioSource playerMovingSource;

    private void Start()
    {
        var audioSources = GetComponents<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            if (audioSource.clip.name == "Player Step Sound")
            {
                playerMovingSource = audioSource;
            }
        }

        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        GetInput();
        DetectDirection();

        PlayerMovingPlay();

        previousPosition = transform.position;
    }

    /// <summary>
    /// ������� ����������� �� ��� Z
    /// </summary>
    public static AxisDirection ZAxisDirection { get; private set; } = AxisDirection.Stay;

    /// <summary>
    /// ������� ����������� �� ��� Y
    /// </summary>
    public static AxisDirection YAxisDirection { get; private set; } = AxisDirection.Stay;

    /// <summary>
    /// ������� ����������� �� ��� X
    /// </summary>
    public static AxisDirection XAxisDirection { get; private set; } = AxisDirection.Stay;

    /// <summary>
    /// �������� ������ � ����������� �� ������� ������ W, A, S, D
    /// </summary>
    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// ��������� ���� ������ ������
    /// </summary>
    private void PlayerMovingPlay()
    {
        if (IsPlayerMoving() && !playerMovingSource.isPlaying)
        {
            playerMovingSource.Play();
        }
    }

    /// <summary>
    /// ����������, � ����� ������� �������� ����� �� �����-���� ���
    /// </summary>
    private void DetectDirection()
    {
        // � �������� ��������� ���� ������ �������� 0.01f, ��� ��� ������ ���� ����� ����� "����� �� �����", ��
        // ��� ��������� ������ �� ���������� �� �������� ��� ������� ���� �� ����

        if (transform.position.z - previousPosition.z > 0.01f)
        {
            ZAxisDirection = AxisDirection.Forward;
        }
        else if (transform.position.z - previousPosition.z < -0.01f)
        {
            ZAxisDirection = AxisDirection.Back;
        }
        else
        {
            ZAxisDirection = AxisDirection.Stay;
        }

        if (transform.position.y - previousPosition.y > 0.01f)
        {
            YAxisDirection = AxisDirection.Forward;
        }
        else if (transform.position.y - previousPosition.y < -0.01f)
        {
            YAxisDirection = AxisDirection.Back;
        }
        else
        {
            YAxisDirection = AxisDirection.Stay;
        }

        if (transform.position.x - previousPosition.x > 0.01f)
        {
            XAxisDirection = AxisDirection.Forward;
        }
        else if (transform.position.x - previousPosition.x < -0.01f)
        {
            XAxisDirection = AxisDirection.Back;
        }
        else
        {
            XAxisDirection = AxisDirection.Stay;
        }
    }

    /// <summary>
    /// ������� ����������� ������ �� ����� �� ����
    /// </summary>
    public enum AxisDirection
    {
        Back = -1,
        Stay,
        Forward
    }

    /// <summary>
    /// �������� �� ����� � ������ ������
    /// </summary>
    public bool IsPlayerMoving()
    {
        if (XAxisDirection != AxisDirection.Stay || YAxisDirection != AxisDirection.Stay || ZAxisDirection != AxisDirection.Stay)
        {
            return true;
        }
        return false;
    }
}