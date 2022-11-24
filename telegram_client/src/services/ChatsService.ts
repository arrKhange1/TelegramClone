import IChat from "../@types/IChat";
import { $api } from "../http/axios";

export default class ChatsService {
    static async getChats(userId: string) {
        const response = await $api.get<IChat[]>(`chats?userid=${userId}`);
        return response;
    }

    static async readPrivateChat(fromId: string, toId: string) {
        const response = await $api.put(`chats/readprivatechat?fromId=${fromId}&toId=${toId}`);
        return response;
    }

    static async readGroupChat(fromId: string, chatId: string) {
        const response = await $api.put(`chats/readgroupchat?fromId=${fromId}&chatId=${chatId}`);
        return response;
    }
}