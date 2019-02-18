using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scent : MonoBehaviour
{
    public LineRenderer line;
    public float scentInterval;
    public int lineLength;
    public int scentSmoothness;
    public int waveSize;
    
    private Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
        StartScentAnimationCycles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePositions()
    {
        Vector3[] oldPositions = new Vector3[line.positionCount];
        line.GetPositions(oldPositions);
        Vector3 startPos = oldPositions[0];
        Vector3 endPos = oldPositions[1];
        Vector3[] newPositions = new Vector3[scentSmoothness + 2];
        newPositions[0] = startPos;
        newPositions[scentSmoothness + 1] = endPos;
        float interval = endPos.z / scentSmoothness;
        float lastZ = 0;
        for (int i = 1; i < scentSmoothness + 1; i++)
        {
            lastZ = lastZ + interval;
            newPositions[i] = new Vector3(0, 0, lastZ);
        }

        line.positionCount = newPositions.Length;
        line.SetPositions(newPositions);
    }

    private void StartScentAnimationCycles()
    {
        positions = new Vector3[scentSmoothness + 2];
        line.GetPositions(positions);
        StartCoroutine(ActivateCycles());
    }

    private IEnumerator ActivateCycles()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            StartCoroutine(AnimateScentPoint(i, true));
            yield return new WaitForSeconds(scentInterval);
        }
    }

    private IEnumerator AnimateScentPoint(int index, bool goingUp)
    {
        for (int i = 0; i < lineLength; i++) 
        {
            Vector3 pos = positions[index];
            float newY = goingUp ? pos.y + 1f / lineLength : pos.y - 1f / lineLength;
            pos = new Vector3(pos.x, newY, pos.z);
            positions[index] = pos;
            line.SetPosition(index, pos);
            yield return new WaitForSeconds(scentInterval);
        }
        yield return new WaitForSeconds(scentInterval * waveSize);
        yield return StartCoroutine(AnimateScentPoint(index, !goingUp));
    }
}
