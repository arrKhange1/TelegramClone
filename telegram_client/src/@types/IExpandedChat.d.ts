export default interface IExpandedChat {
    chatName: string,
    chatStatus: string,
    messages: IMessage[]
}

export interface IMessage {
    userName: string,
    messageText: string
}