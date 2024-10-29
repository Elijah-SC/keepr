import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Vault } from "@/models/Vault.js"
import { Keep } from "@/models/Keep.js";

class VaultService {
  async deleteVault(vaultId) {
    const response = await api.delete(`api/vaults/${vaultId}`)
    logger.log(response.data)
    AppState.activeVault = null
  }
  async getKeepsForVault(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}/keeps`);
    logger.log("got Keeps for vault", response.data);
    const vaultKeeps = response.data.map(keep => new Keep(keep));
    AppState.keepsInVault = vaultKeeps;
  }
  async getVaultById(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}`);
    logger.log("got vault by Id", response.data);
    const newVault = new Vault(response.data)
    AppState.activeVault = newVault
  }
  async createVault(creationData) {
    const response = await api.post(`api/vaults`, creationData);
    logger.log("created Vault", response.data);
    const newVault = new Vault(response.data);
    AppState.vaults.push(newVault);
  }

}

export const vaultsService = new VaultService