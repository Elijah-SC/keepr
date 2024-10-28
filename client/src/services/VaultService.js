import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultService {
  async createVault(creationData) {
    const response = await api.post(`api/vaults`, creationData)
    logger.log("created Vault", response.data)
  }

}

export const vaultsService = new VaultService