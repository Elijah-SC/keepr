import { Keep } from "@/models/Keep.js"
import { AppState } from '../AppState.js'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'
import { Vault } from "@/models/Vault.js"

class AccountService {
  clearGhostData() {
    AppState.keeps = null
  }
  async getAccountKeeps(userId) {
    const response = await api.get(`api/profiles/${userId}/keeps`)
    logger.log("Got My Keeps", response.data)
    const newKeeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = newKeeps;
  }
  async getAccountVaults() {
    const response = await api.get("account/vaults")
    logger.log("got vaults for account", response.data)
    const newVaults = response.data.map(vault => new Vault(vault))
    AppState.vaults = newVaults;
  }
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const accountService = new AccountService()
