export interface IComment{
    commentId: number,
    userId: number, 
    reviewId: number, 
    numLikes: number,
    comment_data: string, 
    public_date: Date,
    user : {userId : string, login : string, avatar : string}
}