using UnityEngine;
using LSL;

public class EEGReceiver : MonoBehaviour
{
    private StreamInlet inlet;
    private float[] sample;
    private int channelCount;

    // Parameters for blink detection
    private float blinkThreshold = 300.0f; // Adjust this value based on the differential signal
    private bool blinkDetected = false;
    private float jumpForce = 5.0f; // Force to apply to make the cube jump

    // Cooldown parameters
    private float cooldownTime = 2.0f; // Time in seconds to wait before detecting another blink
    private float cooldownTimer = 0f;

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Resolve the Muse EEG stream on the network
        StreamInfo[] results = LSL.LSL.resolve_stream("type", "EEG");

        if (results.Length > 0)
        {
            inlet = new StreamInlet(results[0]);
            channelCount = inlet.info().channel_count();
            sample = new float[channelCount];

            Debug.Log("EEG stream found and connected.");
        }
        else
        {
            Debug.LogError("No EEG stream found.");
        }

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on this GameObject.");
        }
    }

    void Update()
    {
        // Always retrieve data from the LSL stream
        if (inlet != null)
        {
            double timestamp = inlet.pull_sample(sample, 0.0);

            if (timestamp != 0.0)
            {
                // Use the difference between AF7 and AF8 channels for blink detection
                float af7Value = sample[1]; // AF7 channel
                float af8Value = sample[2]; // AF8 channel
                float differentialSignal = Mathf.Abs(af7Value - af8Value); // Compute the difference

                // Check for a blink only if the cooldown has expired
                if (cooldownTimer <= 0)
                {
                    if (differentialSignal > blinkThreshold)
                    {
                        if (!blinkDetected) // Ensure the blink is detected only once
                        {
                            blinkDetected = true;
                            Debug.Log("Blink detected!");

                            // Make the cube jump
                            if (rb != null)
                            {
                                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                            }

                            // Start the cooldown timer
                            cooldownTimer = cooldownTime;
                        }
                    }
                    else
                    {
                        blinkDetected = false; // Reset blink detection
                    }
                }
            }
        }

        // Update the cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
}
