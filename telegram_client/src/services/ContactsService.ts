import IContact from "../@types/IContact";
import { $api } from "../http/axios";

export default class ContactsService {
    static async getContacts(userId: string) {
        const response = await $api.get<IContact[]>(`contacts?userid=${userId}`);
        return response;
    }

    static async addContact(userId: string, contactName: string) {
        const response = await $api.post(`contacts?userid=${userId}&contactname=${contactName}`);
        return response;
    }
}