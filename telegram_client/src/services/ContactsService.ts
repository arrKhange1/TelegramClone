import IContact from "../@types/IContact";
import { $api } from "../http/axios";

export default class ContactsService {
    static async getContacts(userId: string) {
        const response = await $api.get<IContact[]>(`contacts?userid=${userId}`);
        return response;
    }
}