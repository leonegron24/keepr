import { Account } from "./Account.js";

export class Vault {
    constructor(data) {
        this.id = data.id;
        this.createdAt = new Date(data.createdAt);
        this.updatedAt = new Date(data.updatedAt);
        this.name = data.name;
        this.description = data.description;
        this.img = data.img;
        this.isPrivate = data.isPrivate;
        this.creatorId = data.creatorId;
        this.creator = new Account(data.creator);
    }
}
