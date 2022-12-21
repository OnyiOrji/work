import ExpenseDate from './ExpenseDate';
import './ExpenseItem.css';

function ExpenseItem(props) {

    let title = props.title;

    const clickHandler = () => {
        title = 'Updated!';
        console.log(title)
    };

    return (
        <div className="expense-item">
            <ExpenseDate date={props.date} />
            <div className="expense-item__description">
                <h2>{props.title}</h2>
                <div className="expense-item__price ">${props.amount}</div>
            </div>
            <button onClick={clickHandler}>Change title</button>
        </div>
    );
}

export default ExpenseItem;