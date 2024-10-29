import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Profile } from "@/models/Profile.js"
import { AppState } from "@/AppState.js"

class ProfileService {
  async getUserProfile(profileId) {
    const response = await api.get(`api/profiles/${profileId}`)
    logger.log("Got Profile", response.data)
    const activeProfile = new Profile(response.data)
    AppState.ActiveProfile = activeProfile
  }

}

export const profileService = new ProfileService()