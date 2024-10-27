import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepsService {
  async getAllKeeps() {
    const response = await api.get("api/keeps")
    logger.log(response.data)
    const newKeeps = response.data.map(KeepPOJO => new Keep(KeepPOJO))
    AppState.keeps = newKeeps
  }

}

export const keepsService = new KeepsService