import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"

class VaultKeepsService {
  async createVaultKeep(creationBody) {
    const response = await api.post(`api/vaultkeeps`, creationBody)
    logger.log('vault Keep created', response.data)
    AppState.activeKeep.kept++
  }
  async deleteVaultKeep(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    logger.log(response.data)
    const KeepIndex = AppState.keepsInVault.findIndex(keep => keep.vaultKeepId == vaultKeepId)
    AppState.keepsInVault.splice(KeepIndex, 1)
  }

}

export const vaultKeepsService = new VaultKeepsService()