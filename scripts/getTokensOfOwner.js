// scripts/getTokensOfOwner.js
const { ethers } = require("hardhat");

async function main() {
    const contractAddress = "0x643D5cf6fdd9Faa3825e194e925D07E290E993D2";
    const walletAddress = "0x204f9781DDcafB4a844fd12250dB15183C67cACB";

    const GameItem = await ethers.getContractFactory("GameItem");
    const gameItem = GameItem.attach(contractAddress);

    const tokensOfOwner = await gameItem.getTokensOfOwner(walletAddress);

    console.log(`Tokens owned by ${walletAddress}:`);
    tokensOfOwner.forEach((tokenURI, index) => {
        console.log(`Token ${index + 1}: ${tokenURI}`);
    });
}

main()
    .then(() => process.exit(0))
    .catch(error => {
        console.error(error);
        process.exit(1);
    });
