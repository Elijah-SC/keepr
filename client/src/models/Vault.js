import { DBItem } from "./DBItem.js";
import { Profile } from "./Profile.js";

export class Vault extends DBItem {
  constructor(data) {
    super(data)
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.isPrivate = data.isPrivate
    this.creator = data.creator ? new Profile(data.creator) : null
  }
}

const data = `public class VaultCreationDTO
{
  [MinLength(1), MaxLength(100)] public string name { get; set; }
  [MinLength(1), MaxLength(1000)] public string Description { get; set; }
  [MinLength(1), MaxLength(1000)] public string Img { get; set; }
  public bool? IsPrivate { get; set; }
}

public class Vault : RepoItem<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool IsPrivate { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}`

const data2 = `{
    "id": 1,
    "name": "Stuff I like",
    "description": "A vault for stuff I like",
    "img": "https://i.redd.it/one-piece-collage-ive-been-working-on-spoilers-for-enies-v0-eccx0dph7cxa1.jpg?width=1371&format=pjpg&auto=webp&s=1b9b56cab75787d69788e01ada9c4b232ad4ab9a",
    "isPrivate": false,
    "creatorId": "66e04bf70483818f681bcaa1",
    "creator": {
        "id": "66e04bf70483818f681bcaa1",
        "name": "Louie",
        "picture": "https://images.unsplash.com/photo-1611923256262-5b9381573b31?q=80&w=200&h=200&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        "coverImg": "https://images.unsplash.com/photo-1566732500818-d76031ac0421?q=80&w=1080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
    }
}`