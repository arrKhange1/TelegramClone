export interface IExpandedChat {
    messages: IMessage[]
}

export interface IPrivateChat extends IExpandedChat {
    userName: string
}

export interface IGroupChat extends IExpandedChat {
    chatName: string,
    groupMembers: number
}

export interface IMessage {
    userName: string,
    messageText: string,
    messageType?: string
}