const hre = require("hardhat");
const NUM_ITEMS = 1;
//const OWNER_ADDRESS = "0x98000edf79B0eb598085721D57d93B5865c87751";

async function main() {

      const GameItem = await hre.ethers.getContractFactory("GameItem");
      //https://bafkreibqmmz6wu73fzkgoxonv7ya7j2ij4eynczk6ko5x25qgqwlmhajje.ipfs.nftstorage.link/
      const gameItem = await GameItem.attach('0xD837D98194884Bc4dEF43EEdc0aB4e22fA20F174')

      for (var i = 1; i <= NUM_ITEMS; i++) {
            await gameItem.mintItem(`https://bafkreiejb54enscvzqlrm4dfqrefiji2x4vmdzduaemfaav3iwgvvt6fk4.ipfs.nftstorage.link/`, {value: hre.ethers.utils.parseEther("0.5")});
      }
}

main()
      .then(() => process.exit(0))
      .catch((error) => {
            console.error(error);
            process.exit(1);
      });
