const hre = require("hardhat");

async function main() {
    const GameItem = await hre.ethers.getContractFactory("GameItems");
    const gameItem = await GameItem.attach('0x6128feAb12605f70b6be3A4f3F316D682120f02a');

    const NUM_ITEMS = 1;
    const tokenURIs = [
        "https://bafkreiczapdwomdlotjqt4yaojyizlgarn4kq57smi3ptkwn5lug5yz7yu.ipfs.nftstorage.link/"
    ];

    for (let i = 0; i < NUM_ITEMS; i++) {
        console.log(`Minting tokens: Batch ${i + 1}`);
        await gameItem.batchMint(tokenURIs);
    }
}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
