using System.Numerics;
using Web3Unity.Scripts.Library.ETHEREUEM.EIP;
using UnityEngine;

public class CheckNFTOwnership : MonoBehaviour
{
    async void Start()
    {
        string contract = "0x693984165233F42fC5CB2aE405ea4D465F8bCc36";
        string account = "0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2";

        BigInteger balance = await ERC721.BalanceOf(contract, account);
        print(balance);
    }
}