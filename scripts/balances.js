const hre = require("hardhat");

async function main() {
  const GameItem = await hre.ethers.getContractFactory("GameItems");
  const gameItem = await GameItem.attach('0xd68B7C666b269B3FC9daAc7a3a446bE32999920E');

  const account = "0x204f9781DDcafB4a844fd12250dB15183C67cACB";
  const totalBalance = await gameItem.getTotalBalance(account);

  console.log(`Total balance for ${account}: ${totalBalance}`);
}

main()
  .then(() => process.exit(0))
  .catch((error) => {
    console.error(error);
    process.exit(1);
  });
