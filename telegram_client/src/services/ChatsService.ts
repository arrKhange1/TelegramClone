import IChat from "../@types/IChat";
import { $api } from "../http/axios";

export default class ChatsService {
    static async getChats(userId: string) {
        const response = await $api.get<IChat[]>(`chats?userid=${userId}`);
        return response;
    }
}