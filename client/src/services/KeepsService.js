import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepsService {
  async getKeepById(keepId) {
    const response = await api.get(`api/keeps/${keepId}`);
    logger.log("Got Keep by Id", response.data);
    const newKeep = new Keep(response.data);
    AppState.activeKeep = newKeep;
  }
  async getAllKeeps() {
    const response = await api.get("api/keeps");
    logger.log(response.data);
    const newKeeps = response.data.map(KeepPOJO => new Keep(KeepPOJO));
    AppState.keeps = newKeeps;
  }

}

export const keepsService = new KeepsService;