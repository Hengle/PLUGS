using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnPhone : MonoBehaviour {

    /* A test call to test call by device functionality 
     */
    public void TestCall()
    {
        Application.OpenURL("tel://235678*"+"%23");
    }

    /*Hard Reset -- A hard reset is traditionally when you kill all power 
     * to the phone and then boot it up from that state. Normally you remove 
     * the battery, then put it back in and boot up.
     */
	public void RestartPhone () {
        Application.OpenURL("tel://"+"%23"+"*2767*3855"+"%23");
	}
	
    /*Factory Reset -- A factory reset results in a full reset of an Android 
     * device to the original settings of the currently-installed ROM. This 
     * process deletes all user data and user installed apps, so the device 
     * looks like it came fresh out of the box. 
     */
    public void FactoryResetPhone ()
    {
        Application.OpenURL("tel://*"+"%23"+"7780"+"%23");
    }
}
