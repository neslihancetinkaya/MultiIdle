using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

public class VirtualClient : MonoBehaviour
{
    [SerializeField] private GameEvent GameEnd;
    [SerializeField] private IntRef ClientMoney;
    [SerializeField] private IntRef Countdown;
    [SerializeField] private TextMeshProUGUI CountDownText;

    private float timeLeft;
    private float clientMoney;
    private float clientMoneyMultiplier = .5f;
    private bool _isGame = true;

    private void Start()
    {
        timeLeft = Countdown.Value;
    }
    void Update()
    {
        if (!_isGame)
            return;

        if(timeLeft > 0)
        {
            clientMoney += Time.deltaTime * clientMoneyMultiplier;
            ClientMoney.Value = (int) clientMoney;
            Countdown.Value = (int) timeLeft;
            CountDownText.text = "Countdown: " + Countdown.Value.ToString();
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
            _isGame = false;
            GameEnd.Raise();
        }
    }
}
