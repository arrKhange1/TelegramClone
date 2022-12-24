export default interface IChat {
    chatId:string,
    chatName: string,
    chatCategory: string
    lastMessageText: string,
    lastMessageSender: string,
    lastMessageTime: string,
    lastMessageType: string,
    unreadMsgs: number
}