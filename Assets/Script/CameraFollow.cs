using UnityEngine;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public string playerTag = "Player";

    [Header("Colliders que limitam a câmera")]
    public List<BoxCollider2D> cameraBoundsColliders;

    private Transform player;
    private float minX, maxX, minY, maxY;
    private bool boundsCalculated = false;

    void Start()
    {
        // Encontra o jogador pela tag
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            player = playerObj.transform;
        else
            Debug.LogError("Player com tag '" + playerTag + "' não encontrado.");

        CalculateBoundsFromList();
    }

    void CalculateBoundsFromList()
    {
        if (cameraBoundsColliders == null || cameraBoundsColliders.Count == 0)
        {
            Debug.LogWarning("Nenhum collider definido na lista 'cameraBoundsColliders'. A câmera não será limitada.");
            return;
        }

        float left = float.MaxValue;
        float right = float.MinValue;
        float bottom = float.MaxValue;
        float top = float.MinValue;

        foreach (var col in cameraBoundsColliders)
        {
            if (col == null) continue;

            Bounds bounds = col.bounds;

            if (bounds.min.x < left) left = bounds.min.x;
            if (bounds.max.x > right) right = bounds.max.x;
            if (bounds.min.y < bottom) bottom = bounds.min.y;
            if (bounds.max.y > top) top = bounds.max.y;
        }

        minX = left;
        maxX = right;
        minY = bottom;
        maxY = top;
        boundsCalculated = true;

        Debug.Log($"[CameraFollow] Limites definidos: minX={minX}, maxX={maxX}, minY={minY}, maxY={maxY}");
    }

    void LateUpdate()
    {
        if (player == null || !boundsCalculated)
            return;

        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = camHalfHeight * Camera.main.aspect;

        // Deseja centralizar no player
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Aplica limites
        float clampedX = Mathf.Clamp(desiredPosition.x, minX + camHalfWidth, maxX - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY + camHalfHeight, maxY - camHalfHeight);

        // Define a posição final direto (sem suavização)
        transform.position = new Vector3(clampedX, clampedY, desiredPosition.z);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (!boundsCalculated) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(minX, maxY, 0));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(maxX, maxY, 0));
    }
#endif
}
