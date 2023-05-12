const AddNotification = (content, notifications, setNotifications) => {
  let id = (~~(Math.random() * 1e8)).toString(16);
  let len = 5;
  setNotifications([
    ...(notifications.length > len - 2
      ? notifications.slice(
          notifications.length - (len - 1),
          notifications.length
        )
      : notifications),
    {
      id: id,
      content: content,
    },
  ]);
};

export default AddNotification;
