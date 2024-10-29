import { DBItem } from "./DBItem.js"
import { Profile } from "./Profile.js"

export class Keep extends DBItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    this.kept = data.kept
    this.creatorId = data.creatorId
    this.vaultKeepId = data.vaultKeepId
    this.creator = data.creator ? new Profile(data.creator) : null
  }
}







const data = {
  "id": 1,
  "name": "Amazing View",
  "description": "Great view from a top of a mountain",
  "img": "https://www.travelandleisure.com/thmb/H_LyBQJ3AZKfg_HGYY5tOH3niB0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/blue-ridge-mountains-USMNTNS0720-c68c0141d720475aa179bace8858fbd1.jpg",
  "views": 2,
  "kept": 0,
  "creatorId": "66e04bf70483818f681bcaa1",
  "creator": {
    "id": "66e04bf70483818f681bcaa1",
    "name": "luffy@grandline.pirates",
    "picture": "https://preview.redd.it/how-would-you-build-luffy-gear-5-v0-3uzhu2a8wh591.jpg?width=1080&crop=smart&auto=webp&s=5a3641d3c37ab033fb4c03677a7bdb48332fc35d",
    "coverImg": "https://images.alphacoders.com/136/thumb-1920-1363606.png"
  }
}