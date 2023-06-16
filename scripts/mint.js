const hre = require("hardhat");
const NUM_ITEMS = 5;
const OWNER_ADDRESS = "0x98000edf79B0eb598085721D57d93B5865c87751";

async function main() {

      const GameItem = await hre.ethers.getContractFactory("GameItem");
      const gameItem = await GameItem.attach('0x191F03d5c7f18C8Cce0f6105Ac3c5D7a95Bad747')

      for (var i = 1; i <= NUM_ITEMS; i++) {
            await gameItem.mintItem(OWNER_ADDRESS, `https://bafkreiczapdwomdlotjqt4yaojyizlgarn4kq57smi3ptkwn5lug5yz7yu.ipfs.nftstorage.link/`);
      }
}

main()
      .then(() => process.exit(0))
      .catch((error) => {
            console.error(error);
            process.exit(1);
      });
