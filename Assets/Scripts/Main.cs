using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using PitchDetector;
using System.Linq;

public class Main : MonoBehaviour
{

    public Text noteText;
    public Text leftMessage;

    public PitchBar pitchBar;


    public Text outputText;

    AudioClip clip;
    string device;




    // Start is called before the first frame update
    void Start()
    {
        MicrophonePitchDetector detector = FindObjectOfType<MicrophonePitchDetector>();
        detector.ToggleRecord();

        // device = Microphone.devices[0];//獲取裝置麥克風

        //dddddclip = Microphone.Start(null, true, 1, 44100);//44100音訊取樣率   固定格式
    }

    // Update is called once per frame
    void Update()
    {
        // if (clip != null)
        // {
        //     float[] data = new float[44100];
        //     clip.GetData(data, 0);
        //     outputText.text = data[0].ToString();
        // }
        // else
        //     outputText.text = "No Clip";

    }


    public void OnDetectPitch(List<float> pitchList, int samples, float db)
    {

        try
        {
            if (db < -35)
            {
                pitchBar.Reset();
                noteText.text = "";
                outputText.text = "no sound.";
            }
            else
            {
                var midis = RAPTPitchDetectorExtensions.HerzToMidi(pitchList);

                float average = (float)midis.Average();
                int roundMidi = Mathf.RoundToInt(average);

                float offset = average - roundMidi + 0.5f;

                string note = RAPTPitchDetectorExtensions.MidiToNote(roundMidi);

                pitchBar.SetHightLight(offset);
                noteText.text = note;
                outputText.text = "db: " + db + "\n" + "midi: " + average + "\n" + note + "\n" + "offset: " + offset;

                Debug.Log("detected " + pitchList.Count + " values from " + samples
                + " samples, db:" + db);
                Debug.Log(midis.NoteString());
            }

        }
        catch (System.Exception e)
        {
            outputText.text = e.Message;
        }

        // RAPTPitchDetectorExtensions.NoteString(midis);
    }


}
